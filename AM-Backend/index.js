const express = require('express');
const bodyparser = require('body-parser');
const sequelize = require('./src/util/database');
const apiVersion = '/v1';
const app = express();

app.use(bodyparser.json());
app.use(bodyparser.urlencoded({extended: false}));

app.use((req, res, next) => {
  res.setHeader('Access-Control-Allow-Origin', '*');
  res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
  next();
});

// Test route
app.get('/', (req, res, next) => {
  res.send('Test route is working');
});

// LOGIN route
app.use(apiVersion + '/login', require('./src/routes/auth.routes'));
// CRUD routes
app.use(apiVersion + '/students', require('./src/routes/students.routes'));

// Error Handling
app.use((error, req, res, next) => {
  console.log(error);
  const status = error.statusCode || 500;
  const message = error.message;
  res.status(status).json({message: message});
});

// Sync database
sequelize
    .sync()
    .then((result) => {
      console.log('Database Connected');
      app.listen(3000);
    })
    .catch((err) => console.log(err));
