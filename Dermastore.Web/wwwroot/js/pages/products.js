"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signalRServer").build();

connection.on("LoadProducts", function () {
    location.href = '/products';
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});