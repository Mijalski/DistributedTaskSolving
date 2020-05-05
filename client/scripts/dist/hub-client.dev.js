"use strict";

var jobTypeName = 'PasswordBruteForcing'; // Required

var algorithmName = null; // Optional and for analytics purposes

var programmingLanguage = null; // Optional and for analytics purposes

var currentWorkUnitId;
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44377/jobInstancesHub").configureLogging(signalR.LogLevel.Information).build();
connection.start().then(function () {
  startWorkUnit();
})["catch"](function (err) {
  return console.error(err.toString());
});
connection.on("ReceiveWorkUnit", function (workUnitId, data) {
  currentWorkUnitId = workUnitId;
  console.log("Received work unit with data: ".concat(data, " (id: ").concat(workUnitId, ")"));
});

function startWorkUnit() {
  connection.invoke('StartWorkOnJobType', jobTypeName, algorithmName, programmingLanguage);
}

function finishWorkUnit(data, isSolved) {
  connection.invoke('FinishWorkUnit', data, isSolved);
}