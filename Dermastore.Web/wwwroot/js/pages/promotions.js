"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signalRServer").build();

connection.on("LoadPromotions", function () {
    location.href = '/promotions';
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});