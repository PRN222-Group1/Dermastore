"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signalRServer").build();

connection.on("LoadOrders", function () {
    location.href = '/orders';
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});