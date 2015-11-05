/* 
Assumptions: 
1.  Searches will not include special regex characters.
    This search performs the search after every key press, if searches
    included greedy regex operators, like *, then the searches could easily
    get out of control. TODO: look at timeouts
*/

$(function () {
    var dnaElement = document.getElementById('dna'),
        searchElement = document.getElementById('search'),
        spanGroupsElement = document.getElementById('span-groups'),
        dnaData = dnaElement ? dnaElement.dataset.result : "",
        spanGroups = spanGroupsElement.checked,
        groupSize = 4,
        findMatches = function () {
            if (dnaElement && dnaData) {
                var regex = new RegExp(searchElement.value.toUpperCase(), "g"),
                    searchLength = searchElement.value.length,
                    result,
                    $baseMatch,
                    matchList = [];

                // clear any previous matches and the match count
                $('#dna').find('span').removeClass('match');
                $('#match-count').text('');

                // on occasion, searches would die when the search length was only 1
                // character. Only perform searches for more than one character as a work around.
                if (searchLength > 1) {
                    // find all the matches
                    while (result = regex.exec(dnaData) !== null) {
                        var matchIndex = regex.lastIndex - searchLength,
                            startsOnGroup = matchIndex % groupSize == 0;

                        // check to see if the user wants to either span across groups
                        // or if the match starts at begining of a group. If either are true
                        // record the match.
                        if (spanGroups || startsOnGroup) {
                            matchList.push(matchIndex);
                        }
                    }

                    // add the match class to all base pairs
                    matchList.forEach(function (position) {
                        for (var i = 0; i < searchLength; i++) {
                            $baseMatch = $('#dna').children('.base').eq(position + i);
                            $baseMatch.addClass('match');
                        }
                    });

                    // update match count
                    $('#match-count').text(matchList.length != 1
                        ? 'Found ' + matchList.length + ' matches!'
                        : 'Found 1 match!');
                }
            }
        };

    // register a callback to handle search input
    searchElement.onkeyup = function () {
        findMatches();
    };

    // register a callback to handle checkbox toggle
    spanGroupsElement.onclick = function (e) {
        spanGroups = spanGroupsElement.checked;
        findMatches();
    }

    // output file contents
    if (dnaElement && dnaData) {
        for (var i = 0; i < dnaData.length; i++) {
            var base = document.createElement('span');
            // append dna data
            base.className = 'base';
            base.innerHTML = dnaData[i];

            // append spaces to separate groups when necessary
            if (i % groupSize == 0) {
                var separator = document.createElement('span');
                separator.className = 'separator';
                separator.innerHTML = " ";
                dnaElement.appendChild(separator);
            }

            dnaElement.appendChild(base);
        }
    }
});