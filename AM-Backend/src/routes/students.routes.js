const controller = require('../controllers/students.controller');
// eslint-disable-next-line max-len
const jwtAuthenticationMiddleware = require('../middleware/jwt-authentication.middleware');

// eslint-disable-next-line new-cap
const router = require('express').Router();

// JWT Authentication route
router.use(jwtAuthenticationMiddleware);

// CRUD Routes /students
router.get('/', controller.getStudents);
router.get('/:studentId', controller.getStudent);
router.post('/', controller.createStudent);
router.put('/:studentId', controller.updateStudent);
router.delete('/:studentId', controller.deleteStudent);

module.exports = router;
