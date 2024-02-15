const jwt = require('jsonwebtoken');
const User = require('../models/user.model');
const secretKey = process.env.JWT_SECRET;

exports.login = async (req, res) => {
  const {username, password} = req.body;

  try {
    // Find the user in the database by username and password
    const user = await User.findOne({where: {username, password}});
    if (!user) {
      return res.status(401).json({message: 'Invalid username or password'});
    }

    // Generate a JWT token
    // eslint-disable-next-line max-len
    const token = jwt.sign({userId: user.id, username: user.username}, secretKey, {expiresIn: '1h'});

    // Send the token back to the client
    res.status(200).json({token});
  } catch (error) {
    console.error('Login error:', error);
    res.status(500).json({message: 'Internal server error'});
  }
};
