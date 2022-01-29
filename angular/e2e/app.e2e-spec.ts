import { AspNetZeroOrganisationUnitCloneTemplatePage } from './app.po';

describe('AspNetZeroOrganisationUnitClone App', function() {
  let page: AspNetZeroOrganisationUnitCloneTemplatePage;

  beforeEach(() => {
    page = new AspNetZeroOrganisationUnitCloneTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
