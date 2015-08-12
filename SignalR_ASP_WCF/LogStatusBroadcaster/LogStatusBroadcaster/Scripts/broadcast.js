$(function() {
    var anaHub = $.connection.statusUpdateHandlerHub; // this is always the class name with the first letter lower case
    console.log(anaHub);


    anaHub.client.listenToStatus = function(message) {
        $("#statusDiv").html(message);
    };
    $.connection.hub.start().done(function() {
        anaHub.server.listenToStatus(); // similarly, this is the function name in the hub with the first letter lowered

    });
});