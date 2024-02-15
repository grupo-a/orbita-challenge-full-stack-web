/**
 * Check if a e-mail is valid.
 * @param {string} email - The CPemailF to be validated.
 * @return {boolean} Returns true if the e-mail is valid, false otherwise.
 */
function isEmailValid(email) {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailRegex.test(email);
}

module.exports = isEmailValid;
