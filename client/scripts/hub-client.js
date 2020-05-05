const jobTypeName = 'PasswordBruteForcing'; // Required
const algorithmName = null; // Optional and for analytics purposes
const programmingLanguage = null; // Optional and for analytics purposes

var currentWorkUnitId;

const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:44377/jobInstancesHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.start().then(function(){
    startWorkUnit();
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveWorkUnit", function (workUnitId, data) {
    currentWorkUnitId = workUnitId;
    console.log(`Received work unit with data: ${data} (id: ${workUnitId})`)
});

function startWorkUnit() {
    connection.invoke('StartWorkOnJobType', jobTypeName, algorithmName, programmingLanguage);
}

function finishWorkUnit(data, isSolved){
    connection.invoke('FinishWorkUnit', data, isSolved);
}