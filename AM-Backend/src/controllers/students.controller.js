const Student = require('../models/student.model');
const isCpfValid = require('../util/cpfvalidator');
const isEmailValid = require('../util/emailvalidator');

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
    return res.status(404).json({message: 'Student not found!'});
  }
  res.status(200).json({student});
};

// Create a student
exports.createStudent = async (req, res, next) => {
  const name = req.body.name;
  const email = req.body.email;
  const cpf = req.body.cpf;

  // Check if CPF is valid
  if (!isCpfValid(cpf)) {
    return res.status(400).json({
      message: 'Invalid CPF. Please provide a valid CPF.',
    });
  }
  // Check if email is valid
  if (!isEmailValid(email)) {
    return res.status(400).json({
      message: 'Invalid email. Please provide a valid email address.',
    });
  }
  const newStudent = await Student.create({
    name,
    email,
    cpf,
  });
  res.status(201).json({
    message: 'Student created successfully!',
    student: newStudent,
  });
};

// Update student
exports.updateStudent = async (req, res, next) => {
  const studentId = req.params.studentId;
  const updatedName = req.body.name;
  const updatedEmail = req.body.email;
  const student = await Student.findByPk(studentId);
  if (!student) {
    return res.status(404).json({message: 'Student not found'});
  }

  // Update name if provided
  if (updatedName !== undefined) {
    student.name = updatedName;
  }
  // Update email if provided and valid
  if (updatedEmail !== undefined && isEmailValid(updatedEmail)) {
    student.email = updatedEmail;
  } else if (updatedEmail !== undefined && !isEmailValid(updatedEmail)) {
    return res.status(400).json({
      message: 'Invalid email. Please provide a valid email address.',
    });
  }

  const updatedStudent = await student.save();
  res.status(200).json({message: 'Student updated', student: updatedStudent});
};

// Delete a student
exports.deleteStudent = async (req, res, next) => {
  const studentId = req.params.studentId;
  const student = await Student.findByPk(studentId);
  if (!student) {
    return res.status(404).json({message: 'Student not found!'});
  }
  await Student.destroy({
    where: {
      ra: studentId,
    },
  });
  res.status(200).json({message: 'Student deleted!'});
};
