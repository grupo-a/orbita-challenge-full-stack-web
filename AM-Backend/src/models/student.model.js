const Sequelize = require('sequelize');
const db = require('../util/database');

const Student = db.define('student', {
  ra: {
    type: Sequelize.INTEGER,
    autoIncrement: true,
    allowNull: false,
    primaryKey: true,
    unique: true,
  },
  name: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  email: {
    type: Sequelize.STRING,
    allowNull: false,
  },
  cpf: {
    type: Sequelize.STRING(11),
    allowNull: false,
  },
});

module.exports = Student;
