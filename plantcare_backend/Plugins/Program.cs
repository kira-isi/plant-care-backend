using System.Data;
using System.Data.SQLite;
using Adapters.reposetories;
using Application.repositoryInterfaces;
using Application.usecases.plantManagment;
using Application.usecases.locationManagment;
using Domain.entities;

// Verbindung & Repositories
IDbConnection connection = new SQLiteConnection("Data Source=plantcare.db");
connection.Open();

var locationRepo = new SqlLocationRepository(connection);
var plantTypeRepo = new SqlPlantTypeRepository(connection);
var plantRepo = new SqlPlantRepository(connection);

// UseCases verdrahten
var createLocation = new CreateLocation(locationRepo);
var createPlantType = new CreatePlantType(plantTypeRepo);
var getAllLocations = new GetAllLocation(locationRepo);
var getAllPlantTypes = new GetAllPlantType(plantTypeRepo);
var createPlant = new CreatePlant(plantRepo);

// Location & Typ erstellen
var locId = await createLocation.ExecuteAsync("Fensterbank", "Südseite");
var typeId = await createPlantType.ExecuteAsync("Gummibaum",100, 1, false);

// Abrufen für Verknüpfung
var location = (await getAllLocations.ExecuteAsync()).First(l => l.Id == locId);
var type = (await getAllPlantTypes.ExecuteAsync()).First(t => t.Id == typeId);

// Pflanze anlegen
var plantId = await createPlant.ExecuteAsync(type, location, "Benni");
Console.WriteLine($"Pflanze '{type.Name}' gespeichert mit ID {plantId}");