const mongoose = require('mongoose');
const { uuid } = require('uuidv4');

const ProfessorSchema = mongoose.Schema({
    professorId: { 
        type: String, 
        trim: true,
        default: uuid 
    },
    date: {
        type: Date,
        default: Date.now
    },
    name: {
        type: String,
        trim: true,
        required: true
    },
    description: {
        type: String,
        trim: true
    }
});

module.exports = mongoose.model('Professor', ProfessorSchema);

