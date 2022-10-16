describe('Bus Schedule Lookup', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001/index.html')
    })

    it('displays list of stops on Route F', () => {
        cy.get('#stopList option').should('have.length', 37)
    })

    it('selects 6126 - Figueroa St & Adams Blvd by click sequence expects a time in the future', function() {
        cy.get('#stopList').should('be.visible').select('6126 - Figueroa St & Adams Blvd', {force: true})
        cy.intercept('/api/route/6126').as('route6126')
        cy.wait('@route6126').then(({response}) => {
            // We are checking for 2 different use cases
            // 1) If the response is 200, we are checking if the time is greater than the current time
            // 2) If the response is 204, we are checking if the response body is empty and the message "No more buses today" is displayed
            // Because the server is calculating the time based on the current time, we are not able to check for a specific time
            
            expect([200,204]).contains(response.statusCode);
            if(response.statusCode == 200) {
                var now = new Date();
                var time = now.getHours() + now.getMinutes();
                expect(response.body.time).to.greaterThan(time);
            }

            if(response.statusCode == 204) {
                expect(response.body).to.eq('');
                expect(cy.get('#nextArrival').should('be.visible').contains('No more buses today'));
            }

        })
    });

    it('selects 6143 - LA Live by click sequence expects a time in the future', function() {
        cy.get('#stopList').should('be.visible').select('6143 - LA Live', {force: true})
        cy.intercept('/api/route/6143').as('route6143')
        cy.wait('@route6143').then(({response}) => {
            // We are checking for 2 different use cases
            // 1) If the response is 200, we are checking if the time is greater than the current time
            // 2) If the response is 204, we are checking if the response body is empty and the message "No more buses today" is displayed
            // Because the server is calculating the time based on the current time, we are not able to check for a specific time
            
            expect([200,204]).contains(response.statusCode);
            if(response.statusCode == 200) {
                var now = new Date();
                var time = now.getHours() + now.getMinutes();
                expect(response.body.time).to.greaterThan(time);
            }
             
            if(response.statusCode == 204) {
                expect(response.body).to.eq(''); 
                expect(cy.get('#nextArrival').should('be.visible').contains('No more buses today'));
            }
        })
    });
});