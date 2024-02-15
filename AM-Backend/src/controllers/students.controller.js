const Student = require('../models/student.model');
const isCpfValid = require('../util/cpfvalidator');
const isEmailValid = require('../util/emailvalidator');

// CRUD Controllers

// get all students
exports.getStudents = (req, res, next) => {
  Student.findAll()
      .then((students) => {
        res.status(200).json({students: students});
      })
      .catch((err) => console.log(err));
};

// get student by id
exports.getStudent = (req, res, next) => {
  const studentId = req.params.studentId;
  Student.findByPk(studentId)
      .then((student) => {
        if (!student) {
          return res.status(404).json({message: 'Student not found!'});
        }
        res.status(200).json({student: student});
      })
      .catch((err) => console.log(err));
};

// create a student
exports.createStudent = (req, res, next) => {
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
  Student.create({
    name,
    email,
    cpf,
  })
      .then((result) => {
        res.status(201).json({
          message: 'Student created successfully!',
          student: result,
        });
      })
      .catch((err) => {
        console.log(err);
      });
};

// update student
exports.updateStudent = (req, res, next) => {
  const studentId = req.params.studentId;
  const updatedName = req.body.name;
  const updatedEmail = req.body.email;

  Student.findByPk(studentId)
      .then((student) => {
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
        return student.save();
      })
      .then((result) => {
        res.status(200).json({message: 'Student updated', student: result});
      })
      .catch((err) => console.log(err));
};


// delete a student
exports.deleteStudent = (req, res, next) => {
  const studentId = req.params.studentId;
  Student.findByPk(studentId)
      .then((student) => {
        if (!student) {
          return res.status(404).json({message: 'Student not found!'});
        }
        return Student.destroy({
          where: {
            ra: studentId,
          },
        });
      })
      .then(() => {
        res.status(200).json({message: 'Student deleted!'});
      })
      .catch((err) => console.log(err));
};
