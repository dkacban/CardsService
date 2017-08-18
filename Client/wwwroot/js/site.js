// Write your Javascript code.

$(document).ready(function () {

    $.ajax({
        url: "http://localhost:52626/api/backlogcards",
        dataType: 'json',
        method: 'GET',
        success: function (cards) {

            $(cards).each(function () {
                $("#backlog").append("<span class='card btn btn-primary'><b>" + this.id + "</b><br/>" + this.note + "</span>");
            });
        },
        error: function () {
            alert("Error");
        }
    });

    $.ajax({
        url: "http://localhost:52626/api/todocards",
        dataType: 'json',
        method: 'GET',
        success: function (cards) {

            $(cards).each(function () {
                $("#to-do").append("<span class='card btn btn-primary'><b>" + this.id + "</b><br/>" + this.note + "</span>");
            });
        },
        error: function () {
            alert("Error");
        }
    });

    $.ajax({
        url: "http://localhost:52626/api/inprogresscards",
        dataType: 'json',
        method: 'GET',
        success: function (cards) {

            $(cards).each(function () {
                console.log(this);
                $("#in-progress").append("<span class='card btn btn-primary'><b>" + this.id + "</b><br/>" + this.note + "</span>");
            });
        },
        error: function () {
            alert("Error");
        }
    });

    $.ajax({
        url: "http://localhost:52626/api/donecards",
        dataType: 'json',
        method: 'GET',
        success: function (cards) {

            $(cards).each(function () {
                $("#done").append("<span class='card btn btn-primary'><b>" + this.id + "</b><br/>" + this.note + "</span>");
            });
        },
        error: function () {
            alert("Error");
        }
    });
}); 


