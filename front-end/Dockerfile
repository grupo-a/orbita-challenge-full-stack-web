FROM node:16.16-alpine

WORKDIR /app-frontend

COPY package*.json ./

RUN npm install

COPY . ./

CMD ["npm", "run", "serve"]