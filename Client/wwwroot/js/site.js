//TODO - refactor those methods - deduplicate code.

var loadBacklogCards = function () {
    $.ajax({
        url: "http://localhost:52626/api/backlogcards",
        dataType: 'json',
        method: 'GET',
        success: function (cards) {
            $("#backlog").text("");

            $(cards).each(function () {
                $("#backlog").append("<span class='card card-backlog btn btn-primary'><b>" + this.id + "</b><br/>" + this.note + "</span>");
            });
            registerAuditClick(".card-backlog");
        },
        error: function () {
            alert("Error");
        }
    });
};

var loadToDoCards = function () {
    $.ajax({
        url: "http://localhost:52626/api/todocards",
        dataType: 'json',
        method: 'GET',
        success: function (cards) {
            $("#to-do").text("");

            $(cards).each(function () {
                $("#to-do").append("<span class='card card-to-do btn btn-primary'><b>" + this.id + "</b><br/>" + this.note + "</span>");
            });
            registerAuditClick(".card-to-do");
        },
        error: function () {
            alert("Error");
        }
    });
}

var loadInProgressCards = function () {
    $.ajax({
        url: "http://localhost:52626/api/inprogresscards",
        dataType: 'json',
        method: 'GET',
        success: function (cards) {
            $("#in-progress").text("");

            $(cards).each(function () {
                console.log(this);
                $("#in-progress").append("<span class='card card-in-progress btn btn-primary'><b>" + this.id + "</b><br/>" + this.note + "</span>");
            });
            registerAuditClick(".card-in-progress");
        },
        error: function () {
            alert("Error");
        }
    });
}

var loadDoneCards = function () {
    $.ajax({
        url: "http://localhost:52626/api/donecards",
        dataType: 'json',
        method: 'GET',
        success: function (cards) {
            $("#done").text("");

            $(cards).each(function () {
                $("#done").append("<span class='card card-done btn btn-primary'><b>" + this.id + "</b><br/>" + this.note + "</span>");
            });
            registerAuditClick(".card-done");
        },
        error: function () {
            alert("Error");
        }
    });
}

var registerAuditClick = function (selector) {
    console.log("register");
    $(selector).click(function () {
        var cardId = this.id;

        $.ajax({
            url: "http://localhost:52626/api/audit?id=" + cardId,
            dataType: 'json',
            method: 'GET',
            success: function (audits) {

                var displayAudit = "";

                $(audits).each(function () {
                    console.log(this);
                    displayAudit += this.date + ":" + this.details + ";";
                });

                alert(displayAudit);
            },
            error: function () {
                alert("Error");
            }
        });
    });
};



var replaceText = function (button, from, to, columnId, callback) {
    $(button).click(function () {
        var fromValue = $(from).val();
        var toValue = $(to).val();

        $.ajax({
            url: "http://localhost:52626/api/backlogcards?id=" + columnId + "&from=" + fromValue + "&to=" + toValue,
            dataType: 'json',
            method: 'PUT',
            error: function () {
                callback();
            },
            success: function () {
                callback();
            }
        });
    });
}

$(document).ready(function () {
    loadBacklogCards();
    loadToDoCards();
    loadDoneCards();
    loadInProgressCards();

    var BacklogColumnId = 1364164;
    var ToDoColumnId = 1364165;
    var InProgressColumnId = 1364166;
    var DoneColumnId = 1364168;

    replaceText('#backlog-replace-text', "#backlog-from", "#backlog-to", BacklogColumnId, loadBacklogCards);
    replaceText('#todo-replace-text', "#todo-from", "#todo-to", ToDoColumnId, loadToDoCards);
    replaceText('#in-progress-replace-text', "#in-progress-from", "#in-progress-to", InProgressColumnId, loadInProgressCards);
    replaceText('#done-replace-text', "#done-from", "#done-to", DoneColumnId, loadDoneCards);
}); 

