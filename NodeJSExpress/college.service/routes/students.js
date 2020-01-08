const express = require('express')

const router = express.Router();

router.get('/', (req, res) => {
    res.send('Students default route.');
});

router.get('/list', (req, res) => {
    res.send('List of Students.');
});

module.exports = router;
