it("Reverse string", () => {
  cy.visit("/");
  cy.get("input").type(
    "The red fox crosses the ice, intent on none of my business."
  );
  cy.get("div").contains(
    "ehT der xof sessorc eht eci, tnetni no enon fo ym ssenisub."
  );
});

export {};
