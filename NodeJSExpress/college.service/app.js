const express = require('express');
const app = express();
const mongoose = require('mongoose');
const bodyParser = require('body-parser')
require('dotenv/config');

app.use(bodyParser.json());

// Import Routes
const professorsRoute = require('./routes/professors');
const studentsRoute = require('./routes/students');

// Middleware (To Import Routes)
app.use('/professors', professorsRoute);
app.use('/students', studentsRoute);

// Routes
app.get('/', (req, res) => {
    res.send('NodeJS express Web API connecting to MongoDb.');
});

// Connecting to the MongoDb Local Instance
mongoose.connect(process.env.MongoDbConnection, { 
    useNewUrlParser: true, useUnifiedTopology: true }, () => {
    console.log('Connected to MongoDb');
});

console.log(`Env Port: ${process.env.PORT}`);
var port = process.env.PORT || 3000;

// Listen to the server
app.listen(port);
console.log(`Server Listening at port ${port}`);