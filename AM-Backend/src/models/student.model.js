const Sequelize = require('sequelize');
const db = require('../util/database');

const Student = db.define('student', {
  id: {
    type: Sequelize.INTEGER,
    autoIncrement: true,
    allowNull: false,
    primaryKey: true,
    unique: true,
  },
  ra: {
    type: Sequelize.INTEGER,
    allowNull: false,
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
    // eslint-disable-next-line new-cap
    type: Sequelize.STRING(11),
    allowNull: false,
  },
});

module.exports = Student;
