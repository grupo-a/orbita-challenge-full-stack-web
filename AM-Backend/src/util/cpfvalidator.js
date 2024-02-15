/**
 * Check if a Brazilian CPF (Cadastro de Pessoas Físicas) is valid.
 * @param {string} cpf - The CPF to be validated.
 * @return {boolean} Returns true if the CPF is valid, false otherwise.
 */
const isCpfValid = (cpf) => {
  // Remove non-digits
  cpf = cpf.replace(/\D/g, '');

  // Check for invalid CPF length
  if (cpf.length !== 11) {
    return false;
  }

  // Check for repeated digits
  if (/^(\d)\1+$/.test(cpf)) {
    return false;
  }

  // Validate CPF checksum
  let sum = 0;
  let mod = 0;

  for (let i = 1; i <= 9; i++) {
    sum += parseInt(cpf.substring(i - 1, i)) * (11 - i);
  }

  mod = (sum * 10) % 11;

  if ((mod === 10) || (mod === 11)) {
    mod = 0;
  }

  if (mod !== parseInt(cpf.substring(9, 10))) {
    return false;
  }

  sum = 0;

  for (let i = 1; i <= 10; i++) {
    sum += parseInt(cpf.substring(i - 1, i)) * (12 - i);
  }

  mod = (sum * 10) % 11;

  if ((mod === 10) || (mod === 11)) {
    mod = 0;
  }

  if (mod !== parseInt(cpf.substring(10, 11))) {
    return false;
  }

  return true;
};

module.exports = isCpfValid;
