import { TestBed, inject } from '@angular/core/testing';

import { PlayersHubService } from './players-hub.service';

describe('PlayersHubService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PlayersHubService]
    });
  });

  it('should be created', inject([PlayersHubService], (service: PlayersHubService) => {
    expect(service).toBeTruthy();
  }));
});
