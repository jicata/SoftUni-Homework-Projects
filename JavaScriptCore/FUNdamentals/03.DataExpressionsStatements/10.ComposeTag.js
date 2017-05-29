function composeTag([fileLocation, alternateText]) {
    console.log(`<img src=\"${fileLocation}\" alt=\"${alternateText}\">`)
}
composeTag(['smiley.gif', 'Smiley Face']);