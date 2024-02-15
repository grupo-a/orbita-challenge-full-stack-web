const Joi = require('joi');
const isCpfValid = require('../util/cpfvalidator');

// Define the Joi schema for student creation
exports.createStudentSchema = Joi.object({
  ra: Joi.number().integer().required(),
  name: Joi.string().required(),
  email: Joi.string().email().required(),
  cpf: Joi.string()
      .custom((value, helpers) => {
        if (!isCpfValid(value)) {
          return helpers.error('any.invalid');
        }
        return value;
      }, 'CPF validation')
      .required(),
});

// Define the Joi schema for updating student
exports.updateStudentSchema = Joi.object({
  name: Joi.string(),
  email: Joi.string().email().required(),
});
