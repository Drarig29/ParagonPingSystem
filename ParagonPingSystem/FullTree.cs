namespace ParagonPingSystem {

    public static class FullTree {

        public static PingTree GetFullTree() => new PingTree {
            Pings = new[] {
                new PingTree {
                    Name = "Attack",
                    Pings = new[] {
                        new PingTree {
                            Name = "Middle Lane",
                            Phrase = "Attack Mid Lane!"
                        },
                        new PingTree {
                            Name = "Right Lane",
                            Phrase = "Attack Right Lane!"
                        },
                        new PingTree {
                            Name = "Camps...",
                            Pings = new[] {
                                new PingTree {
                                    Name = "River Camp",
                                    Phrase = "Attack River Camp!"
                                },
                                new PingTree {
                                    Name = "Gold Camp",
                                    Phrase = "Attack Gold Camp!"
                                },
                                new PingTree {
                                    Name = "Orb Prime",
                                    Phrase = "Attack Orb Prime!"
                                },
                                new PingTree {
                                    Name = "Raptors",
                                    Phrase = "Attack Raptors!"
                                }
                            }
                        },
                        new PingTree {
                            Name = "Left Lane",
                            Phrase = "Attack Left Lane!"
                        }
                    }
                },
                new PingTree {
                    Name = "Alert",
                    Pings = new[] {
                        new PingTree {
                            Name = "Enemies Missing...",
                            Pings = new[] {
                                new PingTree {
                                    Name = "Missing Mid",
                                    Phrase = "Enemy Missing Mid Lane!"
                                },
                                new PingTree {
                                    Name = "Missing Right",
                                    Phrase = "Enemy Missing Right Lane!"
                                },
                                new PingTree {
                                    Name = "Enemy Stealthed",
                                    Phrase = "An enemy is stealthed!"
                                },
                                new PingTree {
                                    Name = "Missing Left",
                                    Phrase = "Enemy Missing Left Lane!"
                                }
                            }
                        },
                        new PingTree {
                            Name = "Retreat",
                            Phrase = "Retreat!"
                        },
                        new PingTree {
                            Name = "Help...",
                            Pings = new[] {
                                new PingTree {
                                    Name = "Help Mid"
                                },
                                new PingTree {
                                    Name = "Help Right"
                                },
                                new PingTree {
                                    Name = "Need Help",
                                    Phrase = "I need help!"
                                },
                                new PingTree {
                                    Name = "Help Left"
                                }
                            }
                        },
                        new PingTree {
                            Name = "On My Way...",
                            Pings = new[] {
                                new PingTree {
                                    Name = "On My Way Mid",
                                    Phrase = "On my way to Mid Lane!"
                                },
                                new PingTree {
                                    Name = "On My Way Right",
                                    Phrase = "On my way to Right Lane!"
                                },
                                new PingTree {
                                    Name = "On My Way",
                                    Phrase = "On My Way!"
                                },
                                new PingTree {
                                    Name = "On My Way Left",
                                    Phrase = "On my way to Left Lane!"
                                }
                            }
                        }
                    }
                },
                new PingTree {
                    Name = "Defend",
                    Pings = new[] {
                        new PingTree {
                            Name = "Careful...",
                            Pings = new[] {
                                new PingTree {
                                    Name = "Careful Mid Lane",
                                    Phrase = "Careful Mid Lane!"
                                },
                                new PingTree {
                                    Name = "Careful Right Lane",
                                    Phrase = "Careful Right Lane!"
                                },
                                new PingTree {
                                    Name = "Careful Jungle",
                                    Phrase = "Careful in the Jungle!"
                                },
                                new PingTree {
                                    Name = "Careful Left Lane",
                                    Phrase = "Careful Left Lane!"
                                }
                            }
                        },
                        new PingTree {
                            Name = "Right Lane",
                            Phrase = "Defend Right Lane!"
                        },
                        new PingTree {
                            Name = "Middle Lane",
                            Phrase = "Defend Middle Lane!"
                        },
                        new PingTree {
                            Name = "Left Lane",
                            Phrase = "Defend Left Lane!"
                        }
                    }
                },
                new PingTree {
                    Name = "Notify",
                    Pings = new[] {
                        new PingTree {
                            Name = "Wards...", //TODO: check if ward phrases are correct, these are guesses
                            Pings = new[] {
                                new PingTree {
                                    Name = "Ward OP",
                                    Phrase = "Ward Orb Prime!"
                                },
                                new PingTree {
                                    Name = "Ward Right",
                                    Phrase = "Ward Right Lane!"
                                },
                                new PingTree {
                                    Name = "Ward Middle",
                                    Phrase = "Ward Mid Lane!"
                                },
                                new PingTree {
                                    Name = "Ward Left",
                                    Phrase = "Ward Left Lane!"
                                }
                            }
                        },
                        new PingTree {
                            Name = "Talk...",
                            Pings = new[] {
                                new PingTree {
                                    Name = "OK",
                                    Phrase = "OK, I'm on it!"
                                },
                                new PingTree {
                                    Name = "Good Job",
                                    Phrase = "Good job!"
                                },
                                new PingTree {
                                    Name = "No",
                                    Phrase = "Not right now."
                                },
                                new PingTree {
                                    Name = "More...",
                                    Pings = new[] {
                                        new PingTree {
                                            Name = "Sorry",
                                            Phrase = "Sorry about that..."
                                        },
                                        new PingTree {
                                            Name = "Cancel That",
                                            Phrase = "Cancel that!"
                                        },
                                        new PingTree {
                                            Name = "Thanks",
                                            Phrase = "Thanks!"
                                        },
                                        new PingTree {
                                            Name = "Good Game",
                                            Phrase = "Good game!"
                                        }
                                    }
                                }
                            }
                        },
                        new PingTree {
                            Name = "Tactics...",
                            Pings = new[] {
                                new PingTree {
                                    Name = "Group Up",
                                    Phrase = "Group up!"
                                },
                                new PingTree {
                                    Name = "Follow Me",
                                    Phrase = "Follow me!"
                                },
                                new PingTree {
                                    Name = "Don't Chase",
                                    Phrase = "Don't chase that enemy!"
                                },
                                new PingTree {
                                    Name = "Ultimate Ready",
                                    Phrase = "Ultimate ready!"
                                }
                            }
                        },
                        new PingTree {
                            Name = "Be Right Back",
                            Phrase = "Be right back!"
                        }
                    }
                }
            }
        };
    }
}