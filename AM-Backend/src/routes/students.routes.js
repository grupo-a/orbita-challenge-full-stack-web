const controller = require('../controllers/students.controller');
// eslint-disable-next-line new-cap
const router = require('express').Router();

// CRUD Routes /students
router.get('/', controller.getStudents);
router.get('/:studentId', controller.getStudent);
router.post('/', controller.createStudent);
router.put('/:studentId', controller.updateStudent);
router.delete('/:studentId', controller.deleteStudent);

module.exports = router;
