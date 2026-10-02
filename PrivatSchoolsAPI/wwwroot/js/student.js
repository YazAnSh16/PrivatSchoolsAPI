(function () {
    "use strict";

    var root = document.getElementById("student-page");
    if (!root) return;

    var currentUserId = root.getAttribute("data-current-user") || "";
    var isAuthenticated = root.getAttribute("data-authenticated") === "true";

    // ===================== API client =====================
    var Api = {
        async: function (url, options) {
            return fetch(url, options || {}).then(function (res) {
                if (res.status === 204) return null;
                if (res.status === 404) return null;
                if (!res.ok) throw new Error("Request failed (" + res.status + ")");
                return res.text().then(function (text) {
                    return text ? JSON.parse(text) : null;
                });
            });
        },
        students: function () { return Api.async("/api/Student"); },
        payments: function (studentId) { return Api.async("/api/Payment/" + studentId); },
        absences: function (studentId) { return Api.async("/api/Absence/" + studentId); },
    };

    // ===================== helpers =====================
    var $ = function (sel) { return document.querySelector(sel); };

    function esc(value) {
        return String(value == null ? "" : value).replace(/[&<>"']/g, function (m) {
            return { "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;", "'": "&#39;" }[m];
        });
    }

    function isEmpty(value) {
        return value === null || value === undefined || value === "";
    }

    function formatDate(value) {
        if (isEmpty(value)) return "—";
        var d = new Date(value);
        if (isNaN(d.getTime())) return "—";
        return d.toLocaleDateString("ar-EG", { year: "numeric", month: "short", day: "numeric" });
    }

    function ageFrom(value) {
        if (isEmpty(value)) return null;
        var d = new Date(value);
        if (isNaN(d.getTime())) return null;
        var now = new Date();
        var age = now.getFullYear() - d.getFullYear();
        var m = now.getMonth() - d.getMonth();
        if (m < 0 || (m === 0 && now.getDate() < d.getDate())) age--;
        return age;
    }

    function initials(name) {
        return String(name || "?")
            .split(/\s+/)
            .filter(Boolean)
            .slice(0, 2)
            .map(function (w) { return w[0]; })
            .join("")
            .toUpperCase();
    }

    function avatarHtml(student) {
        if (student.profileImageUrl) {
            return '<img class="avatar" src="' + esc(student.profileImageUrl) + '" alt="" />';
        }
        return '<div class="avatar-fallback">' + esc(initials(student.name)) + "</div>";
    }

    function money(value) {
        var n = Number(value || 0);
        return n.toLocaleString("ar-EG", { minimumFractionDigits: 0, maximumFractionDigits: 2 });
    }

    function toast(message, type) {
        var box = $("#toasts");
        if (!box) return;
        var t = document.createElement("div");
        t.className = "toast " + (type || "info");
        t.textContent = message;
        box.appendChild(t);
        setTimeout(function () { t.remove(); }, 3000);
    }

    // ===================== state =====================
    var state = {
        students: [],
        selectedId: null,
        loadedPaymentsFor: null,
        loadedAbsencesFor: null,
    };

    // ===================== students =====================
    // summary only: the page never keeps or renders the full student record
    function normalize(s) {
        return {
            id: s.id,
            applicationUserId: s.applicationUserId || "",
            name: s.name || "",
            age: ageFrom(s.birthDate),
            profileImageUrl: s.profileImageUrl || "",
        };
    }

    function showLoading(show) {
        var el = $("#students-loading");
        if (el) el.hidden = !show;
    }

    function renderCards() {
        var grid = $("#students-grid");
        var empty = $("#students-empty");
        var count = $("#students-count");
        if (!grid) return;

        if (!state.students.length) {
            grid.hidden = true;
            grid.innerHTML = "";
            if (empty) empty.hidden = false;
            if (count) count.textContent = "";
            return;
        }

        if (empty) empty.hidden = true;
        grid.hidden = false;
        if (count) count.textContent = "عدد الطلاب: " + state.students.length;

        grid.innerHTML = state.students.map(function (s) {
            var meta = s.age !== null ? s.age + " سنة" : "";

            return (
                '<button type="button" class="student-card' +
                (state.selectedId === s.id ? " is-selected" : "") +
                '" data-student-id="' + esc(s.id) + '">' +
                '<div class="student-card-top">' +
                avatarHtml(s) +
                "<div>" +
                '<div class="student-name">' + esc(s.name) + "</div>" +
                '<div class="student-meta">' + (meta ? esc(meta) : "—") + "</div>" +
                "</div></div>" +
                "</button>"
            );
        }).join("");
    }

    function selectStudent(id) {
        var student = state.students.find(function (s) { return String(s.id) === String(id); });
        if (!student) return;

        state.selectedId = student.id;
        renderCards();
        renderPanel(student);

        var panel = $("#student-panel");
        if (panel) {
            panel.hidden = false;
            panel.scrollIntoView({ behavior: "smooth", block: "start" });
        }

        // reset tab state
        showTab("tests");
        loadPayments(student.id);
        loadAbsences(student.id);
    }

    // ===================== student info =====================
    // summary only: name, age and avatar — no private details (address, phones, parents' jobs…)
    function renderPanel(s) {
        var avatar = $("#stu-avatar");
        if (avatar) avatar.innerHTML = avatarHtml(s);

        var age = s.age;
        var name = $("#stu-name");
        if (name) name.textContent = s.name || "";

        var sub = $("#stu-sub");
        if (sub) {
            sub.textContent = age !== null ? "العمر: " + age + " سنة" : "";
        }
    }

    // ===================== tabs =====================
    function showTab(name) {
        var buttons = document.querySelectorAll("#student-tabs .nav-link");
        Array.prototype.forEach.call(buttons, function (btn) {
            btn.classList.toggle("active", btn.getAttribute("data-tab") === name);
        });

        var panes = document.querySelectorAll(".tab-content .tab-pane");
        Array.prototype.forEach.call(panes, function (pane) {
            pane.classList.toggle("active", pane.id === "tab-" + name);
        });
    }

    // ===================== absences =====================
    function loadAbsences(studentId) {
        var loading = $("#absences-loading");
        var empty = $("#absences-empty");
        var wrap = $("#absences-wrap");

        if (state.loadedAbsencesFor === studentId) return;
        state.loadedAbsencesFor = studentId;

        if (loading) loading.hidden = false;
        if (empty) empty.hidden = true;
        if (wrap) wrap.hidden = true;

        Api.absences(studentId)
            .then(function (rows) {
                renderAbsences(rows || []);
            })
            .catch(function () {
                renderAbsences([]);
                toast("تعذر تحميل سجلات الغياب", "error");
            })
            .then(function () {
                if (loading) loading.hidden = true;
            });
    }

    function renderAbsences(rows) {
        var empty = $("#absences-empty");
        var wrap = $("#absences-wrap");
        var body = $("#absences-body");
        if (!body) return;

        if (!rows.length) {
            if (empty) empty.hidden = false;
            if (wrap) wrap.hidden = true;
            return;
        }

        body.innerHTML = rows.map(function (r) {
            var present = r.result === true;
            return (
                "<tr>" +
                "<td>" + esc(formatDate(r.absenceDate)) + "</td>" +
                '<td><span class="badge ' + (present ? "badge-success" : "badge-danger") + '">' +
                (present ? "حاضر" : "غائب") +
                "</span></td>" +
                "</tr>"
            );
        }).join("");

        if (empty) empty.hidden = true;
        if (wrap) wrap.hidden = false;
    }

    // ===================== payments =====================
    function loadPayments(studentId) {
        var loading = $("#payments-loading");
        var empty = $("#payments-empty");
        var wrap = $("#payments-wrap");

        if (state.loadedPaymentsFor === studentId) return;
        state.loadedPaymentsFor = studentId;

        if (loading) loading.hidden = false;
        if (empty) empty.hidden = true;
        if (wrap) wrap.hidden = true;

        Api.payments(studentId)
            .then(function (rows) {
                renderPayments(rows || []);
            })
            .catch(function () {
                renderPayments([]);
                toast("تعذر تحميل سجلات المدفوعات", "error");
            })
            .then(function () {
                if (loading) loading.hidden = true;
            });
    }

    function renderPayments(rows) {
        var empty = $("#payments-empty");
        var wrap = $("#payments-wrap");
        var body = $("#payments-body");
        if (!body) return;

        if (!rows.length) {
            if (empty) empty.hidden = false;
            if (wrap) wrap.hidden = true;
            return;
        }

        body.innerHTML = rows.map(function (p) {
            var paid = Number(p.paidAmount != null ? p.paidAmount : p.amount || 0);
            var total = Number(p.totalAmount || 0);
            var remaining = Math.max(total - paid, 0);

            return (
                "<tr>" +
                "<td>" + esc(formatDate(p.paymentDate)) + "</td>" +
                "<td>" + money(paid) + "</td>" +
                "<td>" + money(remaining) + "</td>" +
                "<td>" + money(total) + "</td>" +
                "</tr>"
            );
        }).join("");

        if (empty) empty.hidden = true;
        if (wrap) wrap.hidden = false;
    }

    // ===================== init =====================
    function init() {
        if (!isAuthenticated) {
            showLoading(false);
            var empty = $("#students-empty");
            if (empty) {
                empty.hidden = false;
                empty.innerHTML =
                    "<strong>سجّل الدخول أولاً</strong>" +
                    'لاستعراض الطلاب المرتبطة بحسابك، <a href="/Identity/Account/Login">سجّل الدخول</a>.';
            }
            return;
        }

        var grid = $("#students-grid");
        if (grid) {
            grid.addEventListener("click", function (e) {
                var card = e.target.closest(".student-card");
                if (card) selectStudent(card.getAttribute("data-student-id"));
            });
        }

        var tabs = $("#student-tabs");
        if (tabs) {
            tabs.addEventListener("click", function (e) {
                var btn = e.target.closest(".nav-link");
                if (btn) showTab(btn.getAttribute("data-tab"));
            });
        }

        showLoading(true);

        Api.students()
            .then(function (rows) {
                var all = (rows || []).map(normalize);
                // only the students that belong to the signed-in account
                state.students = all.filter(function (s) {
                    return s.applicationUserId === currentUserId;
                });
            })
            .catch(function () {
                state.students = [];
                toast("تعذر تحميل قائمة الطلاب", "error");
            })
            .then(function () {
                showLoading(false);
                renderCards();

                // single student -> open it straight away
                if (state.students.length === 1) {
                    selectStudent(state.students[0].id);
                }
            });
    }

    document.addEventListener("DOMContentLoaded", init);
})();
