
        function fromJSONToHTMLTable(input){
            input = (JSON.parse(input));
            let output = ['<table>'];
            let row = ['<tr>'];
            for (const key of [...Object.keys(input[0])]) {
                row.push(`<th>${key}</th>`);
            }
            row.push('</tr>');
            output.push(row.join(''));

            for (const obj of input) {
                row = ['<tr>'];
                    for (const value of [...Object.values(obj)]) {
                        row.push(`<td>${value}</td>`);
                    }
                row.push('</tr>');
                output.push(row.join(''));
            }
            output.push('</table>');
            return output.join('\n');
        }




        fromJSONToHTMLTable(
            '[{"Name":"Stamat","Score":5.5},{"Name":"Rumen","Score":6}]')