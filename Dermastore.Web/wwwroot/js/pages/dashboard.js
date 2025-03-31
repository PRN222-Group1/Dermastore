"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signalRServer").build();

connection.on("LoadDashboard", function () {
    location.href = '/dashboard';
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});