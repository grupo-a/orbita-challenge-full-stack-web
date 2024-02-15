FROM node:20

# Create app directory
WORKDIR /app

# Copy both packages to directory
COPY package*.json ./
# Install content from the packages
RUN npm install

# Bundle app source
COPY . .

# Open and expose port that our backend will run
EXPOSE 3000

# Runs the project
CMD [ "node","index.js"]