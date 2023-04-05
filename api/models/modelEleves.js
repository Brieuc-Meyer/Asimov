/**
 * @Auteur Brieuc Meyer
 * @Version 1.0.0
*/

//récuperer le module de connexion
let modelConnexion = require('./modelConnexion.js')
let mysqlConnexion = modelConnexion.mysqlConnexion

//export des methodes contenant les requettes SQL
module.exports = {

    /**
     * Médhodes d'instantiations des promesses de résultat de  @requetteSQL 
     * si @err est true la promesse est @return rejeté @reject avec le message d'erreur @err
     * sinon @return @resolve avec les donnés @data de la @requetteSQL
     * !  on ne peut résolve q'une @data par promesse  !
    */

    async modelAfficherNotesUnEleve(req, res) {


        return new Promise((resolve, reject) => {
            //ORDER BY afin que pas de mutuelle soit selected
            let eleve_id = req.params.eleve_id

            let requeteSQL = 'SELECT notes.*, perso_nom, mat_nom FROM notes, matieres, personnels WHERE note_eleve_id = ? AND note_mat_id = mat_id AND note_prof_id = perso_id'
            mysqlConnexion.query(requeteSQL,[eleve_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    },

    async modelAfficherMoyenneParMatiere(req, res) {


        return new Promise((resolve, reject) => {
            //ORDER BY afin que pas de mutuelle soit selected
            let eleve_id = req.params.eleve_id

            let requeteSQL = 'SELECT matieres.mat_nom, AVG(notes.note_pourcent) Moyenne FROM notes, matieres, eleves WHERE notes.note_eleve_id = ? AND notes.note_mat_id = matieres.mat_id group by notes.note_mat_id'
            mysqlConnexion.query(requeteSQL,[eleve_id], (err, data) => {

                if (err) {
                    return reject(err)

                }
                return resolve(data)
            })
        }
        )
    }


}