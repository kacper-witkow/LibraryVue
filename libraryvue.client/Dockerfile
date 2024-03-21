FROM node:16

# install simple http server for serving static content
RUN npm install -g http-server

# make the 'app' folder the current working directory
WORKDIR /app

# copy both 'package.json' and 'package-lock.json' (if available)
COPY libraryvue.client/package.json ./

# install project dependencies
RUN npm install

# copy project files and folders to the current working directory (i.e. 'app' folder)
COPY libraryvue.client/. .

# build app for production with minification
RUN npm run build

EXPOSE 5173
CMD [ "http-server", "dist", "-p 5173" ]