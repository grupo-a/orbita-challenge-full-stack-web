const jwt = require('jsonwebtoken');
const User = require('../models/user.model');
const secretKey = process.env.JWT_SECRET;

exports.login = async (req, res) => {
  const {username, password} = req.body;

  // Find the user in the database by username and password
  const user = await User.findOne({where: {username, password}});

  if (!user) {
    return res.sendStatus(401);
  }

  // Generate a JWT token
  // eslint-disable-next-line max-len
  const token = jwt.sign({userId: user.id, username: user.username}, secretKey, {expiresIn: '1h'});

  // Send the token back to the client
  res.status(200).json({token});
};
