"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signalRServer").build();

connection.on("LoadAccounts", function () {
    location.href = '/profile';
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});