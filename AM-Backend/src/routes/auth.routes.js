const authController = require('../controllers/users.controller');
// eslint-disable-next-line new-cap
const router = require('express').Router();

// POST /login - Login route
router.post('/', authController.login);

module.exports = router;
