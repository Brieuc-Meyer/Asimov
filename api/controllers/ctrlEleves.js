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

    async afficherNotesUnEleve(res) {

        try {
            let data = await modelEleves.modelAfficherNotesUnEleve()
            if (data) {
                //console.log(data)
                res.status(200).json(data)
            }
        } catch (error) {
            console.log(error)
        }


    }

}