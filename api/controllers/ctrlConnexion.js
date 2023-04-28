/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
 * @Crédits : Web Dev Simplified => construire et utiliser la métode testAuthentification() dans les routes https://www.youtube.com/watch?v=-RCnNyD0L-s&t=905s&pp=ugMICgJmchABGAE%3D
 *          : Web Dev Junkie => créer un cookie de session uuid-4 et le parser lorsqu'il transite par la longue chaine de charactères du header https://www.youtube.com/watch?v=BgsQrOHNKeY&t=790s&ab_channel=WebDevJunkie
*/

const modelConnexion = require('../models/modelConnexion.js')
//middleware pour créer des uuids de sessions sous ce format : 'da8d572d-411e-4f62-b267-d6b122582637'
const sessions = require('express-session');

module.exports = {


    async testConnexionEleves(req, res) {


        try {
            let data = await modelConnexion.modeltestConnexionEleves(req, res)
            console.log(data)

            if (typeof data[0] === "object") {

                randomNumber = Math.floor(Math.random()*10001)
                res.cookie('session',randomNumber, { maxAge: 900000, httpOnly: true })

                res.json("Bonjour " + data[0].eleve_nom + ";" + data[0].eleve_id)

            } else{
                res.json("Connexion refusé : identifiant ou mot de pass incorrecte")
            }


        } catch (error) {
            console.log(error)
        }

    },
    
    async testConnexionPersonnels(req, res) {


        let perso_identifiant = req.params.perso_identifiant
        let perso_mdp = req.params.perso_mdp

        try {
            let data = await modelConnexion.modeltestConnexionPersonnels(req, res)
            console.log(data)
            if (typeof data[0] === "object") {

                randomNumber = Math.floor(Math.random()*10001)
                res.cookie('session',randomNumber, { maxAge: 900000, httpOnly: true })

                res.json("Bonjour " + data[0].perso_nom + ";" + data[0].perso_id + ";" + data[0].perso_proviseur_on)

            } else{
                res.json("Connexion refusé : identifiant ou mot de pass incorrecte")
            }
        } catch (error) {
            console.log(error)
        }

    },

    async testDeconnetion(req, res) {

        const sessionId = req.headers.cookie?.split('session=')[1]

        if (sessionId) {
            res.clearCookie('session')
            res.json("Cookie supprimé")
        } else {
            res.json("Cookie non présent")
        }
    },





    //middleware qui test la présence d'un cookie de session
    async testAuthentification(req, res, next) {

        //console.log(sessions)
        //console.log(req.headers.cookie?.split('session=')[1])
        
        const sessionId = req.headers.cookie?.split('session=')[1]

        console.log(sessionId)
        //si impossible de trouvrer la valeur après la clé "session="
        if (!sessionId) {
            res.json("Cookie session non présent")
        } else { 
            next()
        }
    },

}