const {faker} = require('@faker-js/faker');
const Student = require('../models/student.model');

// Function to generate a random valid CPF
const generateRandomCPF = () => {
  let cpf = '';
  for (let i = 0; i < 9; i++) {
    cpf += Math.floor(Math.random() * 10);
  }
  cpf += calculateVerifierDigits(cpf);
  cpf += calculateVerifierDigits(cpf);
  return cpf;
};

// Function to calculate the verifier digits for a given CPF
const calculateVerifierDigits = (cpf) => {
  let sum = 0;
  let multiplier = cpf.length + 1;
  for (const digit of cpf) {
    sum += Number(digit) * multiplier;
    multiplier--;
  }
  const remainder = sum % 11;
  return remainder < 2 ? '0' : String(11 - remainder);
};

// Function to generate sample student data
const generateStudents = (count) => {
  const students = [];
  for (let i = 0; i < count; i++) {
    const ra = faker.number.int({max: 999999});
    const name = faker.person.fullName();
    const email = faker.internet.email();
    const cpf = generateRandomCPF();
    students.push({ra, name, email, cpf});
  }
  return students;
};

// Generate 50 sample students
const sampleStudents = generateStudents(50);

/**
 * Populates the students table with sample data
 */
async function seedStudents() {
  try {
    // Delete existing students (optional, depending on your requirements)
    await Student.destroy({truncate: true});

    // Insert sample students into the database
    await Student.bulkCreate(sampleStudents);

    console.log('Sample students seeded successfully');
  } catch (error) {
    console.error('Error seeding sample students:', error);
  }
}

seedStudents();
