/**
 * Created by Maika on 16-Feb-17.
 */
function CountOccurance(stringAndLetter){
    var string = stringAndLetter[0];
    var letter = stringAndLetter[1];
    var occurances = 0;
    for(i=0; i<string.length;i++){
        if(string[i]===letter)
            occurances++;
    }
    console.log(occurances);
}
CountOccurance(['panther', 'n']);