const express = require('express');
const mongoose = require('mongoose');
const routes = require('./routes');

const server = express();

mongoose.connect('mongodb+srv://omnistack:uchiha98@cluster0-4gd2p.azure.mongodb.net/omnistack8?retryWrites=true&w=majority'{
    useNewUrlParser: true
});

server.use(express.json());
server.use(routes);

server.listen(3333);