/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
*/
const express = require('express')
const Routeur = require('./routes/routes.js')
const dotenv = require('dotenv')


let app = express()
//liens vers les dossiers de travail
app.set('view engine', 'ejs')
app.use(express.static('assets'))

dotenv.config()
app.use(express.urlencoded())
//config du middleware express-sessions


app.use('/', Routeur)


//require les file systems, crées avec la commende linux du git bash : 
//openssl req -nodes -new -x509 -keyout server.key -out server.cert
const fs = require('fs')

//créer un serveur HTTPS 
const https = require('https')
const path = require('path')

//donner le chemin vers les certificats autos-signés
const key = fs.readFileSync(path.join(__dirname, 'certificates', 'server.key'));
const cert = fs.readFileSync(path.join(__dirname, 'certificates', 'server.cert'));
const options = { key, cert };


const port = 3000

https.createServer(options, app).listen(port, () => {
 console.log(`server démarré     en HTTPS. Go to https://localhost:${port}`);
 }); 


app.get('/', (req, res) => {
    res.send('Serveur de la Pharmacie Sauteuhz est actif')
})

//gerer 404
Routeur.use((req, res) => {
    res.status(404).redirect('accueil')
});

//commande pour lancer :
//npx nodemon index.js

//lien de test : https://localhost:3000/accueil
