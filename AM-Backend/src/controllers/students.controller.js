const Student = require('../models/student.model');
const {createStudentSchema} = require('../util/studentvalidator');
const {updateStudentSchema} = require('../util/studentvalidator');
// CRUD Controllers

// Get all students
exports.getStudents = async (req, res, next) => {
  const students = await Student.findAll();
  res.status(200).json({students});
};

// Get student by id
exports.getStudent = async (req, res, next) => {
  const studentId = req.params.studentId;
  const student = await Student.findByPk(studentId);
  if (!student) {
    return res.sendStatus(404);
  }
  res.status(200).json({student});
};

// Create a student
exports.createStudent = async (req, res, next) => {
  const {error, value} = createStudentSchema.validate(req.body);
  if (error) {
    return res.status(400).json({message: error.details[0].message});
  }

  const {ra, name, email, cpf} = value;
  const newStudent = await Student.create({
    ra,
    name,
    email,
    cpf,
  });
  res.status(201).json({newStudent});
};

// Update student
exports.updateStudent = async (req, res, next) => {
  const studentId = req.params.studentId;
  const updatedName = req.body.name;
  const updatedEmail = req.body.email;

  // Validate request body
  // eslint-disable-next-line max-len
  const {error} = updateStudentSchema.validate({name: updatedName, email: updatedEmail});
  if (error) {
    return res.status(400).json({message: error.details[0].message});
  }

  const student = await Student.findByPk(studentId);
  if (!student) {
    return res.sendStatus(404);
  }

  // Update name if provided
  if (updatedName !== undefined) {
    student.name = updatedName;
  }

  // Update email if provided
  if (updatedEmail !== undefined) {
    student.email = updatedEmail;
  }

  const updatedStudent = await student.save();
  res.status(200).json({updatedStudent});
};

// Delete a student
exports.deleteStudent = async (req, res, next) => {
  const studentId = req.params.studentId;
  const student = await Student.findByPk(studentId);
  if (!student) {
    return res.sendStatus(404);
  }
  await Student.destroy({
    where: {
      ra: studentId,
    },
  });
  res.sendStatus(204);
};
