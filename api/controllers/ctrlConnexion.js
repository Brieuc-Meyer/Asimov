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


        let eleve_identifiant = req.params.eleve_identifiant
        let eleve_mdp = req.params.eleve_mdp

        try {
            let data = await modelConnexion.modeltestConnexionEleves(req, res)
            console.log(data)

            if (typeof data[0] === "object") {

                res.json("Bonjour " + data[0].eleve_nom)

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

                res.json("Bonjour " + data[0].perso_nom)

            } else{
                res.json("Connexion refusé : identifiant ou mot de pass incorrecte")
            }
        } catch (error) {
            console.log(error)
        }

    },






    //middleware qui test la présence d'un cookie de session
    async testAuthentification(req, res, next) {




        // XXX à enelever pour reelement tester l'authentification
        return next()
        




        //console.log(sessions)
        //console.log(req.headers.cookie?.split('session=')[1])
        
        const sessionId = req.headers.cookie?.split('session=')[1]
        
        const userSession = sessions[sessionId]
        //si impossible de trouvrer la valeur après la clé "session="
        if (!userSession) {
            res.render('connexion')

        } else { 
            
            try {
                //prochaine instruction sera le controlleur placé apres l'appel de cette fonction
                next()
            } catch (error) {
                console.log(error)
            }
    
        }
    },


}