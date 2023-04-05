/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
*/

//importer les models d'accès aux donnés (requetes SQL)
const modelEleves = require('../models/modelEleves.js')


module.exports = {

    /**
    * méthodes qui envoient la @req au @modelMedecin () , sans bloquer le thread principal.
    * le resultat @res , est d'afficher les données contenues dans @data et/ou de rediriger après une opération réussi vers la BDD .
    */

    async afficherNotesUnEleve(req, res) {

        try {
            let data = await modelEleves.modelAfficherNotesUnEleve(req, res)
            if (data) {
                //console.log(data)
                res.json(data)
            }
        } catch (error) {
            console.log(error)
        }


    },

    async afficherMoyennesEleveParMatiere(req, res) {

        try {
            let data = await modelEleves.modelAfficherMoyenneParMatiere(req, res)
            if (data) {
                //console.log(data)
                res.json(data)
            }
        } catch (error) {
            console.log(error)
        }
    }

}