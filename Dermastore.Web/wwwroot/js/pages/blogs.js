"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signalRServer").build();

connection.on("LoadBlogs", function () {
    location.href = '/blogs';
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});