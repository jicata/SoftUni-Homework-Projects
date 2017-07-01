/*jshint esversion: 6 */
function forumPost(input) {
    this.calculateScore = function () {
        let upvotes = this.upvotes;
        let downvotes = this.downvotes;
        let balance = upvotes - downvotes;

        let totalVotes = this.upvotes + this.downvotes;
        let upvotesPercentage = (upvotes / totalVotes ) * 100;

        let rating = 'new';
        if(totalVotes >=10){
            if(upvotesPercentage > 66){
                rating = 'hot';
            }
            else if(balance < 0){
                rating = 'unpopular'
            }
            else if(upvotes > 100 || downvotes > 100){
                rating = 'controversial'
            }
        }

        if (upvotes + downvotes > 50) {
            let obfuscator = 0;
            if (upvotes > downvotes) {
                obfuscator = Math.ceil(upvotes * 0.25);
            }
            else {
                obfuscator = Math.ceil(downvotes * 0.25);
            }
            upvotes += obfuscator;
            downvotes += obfuscator;
        }
        return [upvotes,downvotes,balance,rating];
    };
    switch (input) {
        case 'upvote':
            this.upvotes++;
            break;
        case 'downvote':
            this.downvotes++;
            break;
        case 'score':
            return this.calculateScore();
    }

}
// let randomObject = {
//     id: '3',
//     author: 'emil',
//     content: 'wazaaaaa',
//     upvotes: 100,
//     downvotes: 100,
//     calc : forumPost
// };
// randomObject.calc('upvote');
// randomObject.calc('downvote');
// console.log(randomObject.calc('score'));
