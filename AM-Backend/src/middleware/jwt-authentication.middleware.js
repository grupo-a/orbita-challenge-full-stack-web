/* eslint-disable max-len */
const jwt = require('jsonwebtoken');
const secretKey = process.env.JWT_SECRET;

module.exports = async (req, res, next) => {
  // Get the token from the request headers
  const token = req.headers.authorization.split(' ')[1];

  // Check if token is provided
  if (!token) {
    return res.status(401).json({message: 'Authentication failed: Token not provided'});
  }
  // Verify the token using your secret key
  const decodedToken = await jwt.verify(token, secretKey);
  // Attach the decoded token to the request object for use in subsequent middleware or route handlers
  req.userData = {userId: decodedToken.userId, username: decodedToken.username};
  // Call next middleware or route handler
  next();
};
