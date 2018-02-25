CREATE TABLE [dbo].[Greet] (
	[UniqueId] [uniqueidentifier] NOT NULL,
	[SequenceOrderId] [int] IDENTITY (1, 1) NOT NULL,
	[Dated] [datetime] NOT NULL,
	[Sign] [int] NOT NULL,
	[ScriptureReference] [varchar] (255)  NOT NULL,
	[ScriptureReferenceURI] [varchar] (512)  NULL,
	[Actor] [varchar] (50)  NOT NULL,
	[Ambassador] [varchar] (50)  NULL,
	[AmbassadorPopulation] [int] NULL,
	[Recipient] [varchar] (255)  NOT NULL,
	[Audience] [varchar] (255)  NULL,
	[Saying] [varchar] (255)  NOT NULL,
	[Classification] [varchar] (255)  NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Greet] ADD 
	CONSTRAINT [DF_Greet_UniqueId] DEFAULT (newid()) FOR [UniqueId],
	CONSTRAINT [DF_Greet_Dated] DEFAULT ('7/1/2003') FOR [Dated],
	CONSTRAINT [PK_Greet] PRIMARY KEY  NONCLUSTERED 
	(
		[Sign]
	)  ON [PRIMARY] 
GO

/*
ALTER TABLE GreetRelease20030701 DROP DF_Greet_Dated
ALTER TABLE GreetRelease20030701 DROP DF_Greet_UniqueId
*/

/*
The man said, This is now bone of bones and flesh and of my flesh; she shall be called woman, for she was taken out of man. For this reason a man will leave his father and mother and be united to his wife, and they will become one flesh (Genesis 2:23-24).

1. And David sent out ten young men, and David said unto the young men, Get you up to Carmel, and go to Nabal, and greet him in my name (1 Samuel 25:5).
2  And greetings in the markets, and to be called of men, Rabbi, Rabbi (Matthew 23:7).
2  Woe unto you, Pharisees! for ye love the uppermost seats in the synagogues, and greetings in the markets (Luke 11:43).
2  Beware of the scribes, which desire to walk in long robes, and love greetings in the markets, and the highest seats in the synagogues, and the chief rooms at feasts (Luke 20:46).
3. And they wrote letters by them after this manner; The apostles and elders and brethren send greeting unto the brethren which are of the Gentiles in Antioch and Syria and Cilicia (Acts 15:23).
4. Claudius Lysias unto the most excellent governor Felix sendeth greeting (Acts 23:26).
5. Greet Priscilla and Aquila my helpers in Christ Jesus (Romans 16:3).
6. Likewise greet the church that is in their house. Salute my well-beloved Epaenetus, who is the firstfruits of Achaia unto Christ (Romans 16:5).
7. Greet Mary, who bestowed much labour on us (Romans 16:6).
8. Greet Amplias my beloved in the Lord (Romans 16:8).
9. Salute Herodion my kinsman. Greet them that be of the household of Narcissus, which are in the Lord (Romans 16:11).
10. All the brethren greet you. Greet ye one another with an holy kiss (1 Corinthians 16:20).
11. Greet one another with an holy kiss (2 Corinthians 13:12).
12. Salute every saint in Christ Jesus. The brethren which are with me greet you (Philippians 4:21).
13. Luke, the beloved physician, and Demas, greet you (Colossians 4:14).
14. Greet all the brethren with an holy kiss (1 Thessalonians 5:26).
15. Do thy diligence to come before winter. Eubulus greets you, and Pudens, and Linus, and Claudia, and all the brethren (2 Timothy 4:21).
16. All that are with me salute thee. Greet them that love us in the faith. Grace be with you all. Amen (Titus 3:15).
17. James, a servant of God and of the Lord Jesus Christ, to the twelve tribes which are scattered abroad, greeting (James 1:1).
18. Greet ye one another with a kiss of charity. Peace be with you all that are in Christ Jesus. Amen (1 Peter 5:14).
19. The children of your elect sister greet you. Amen (2 John 1:13).
20. But I trust I shall shortly see you, and we shall speak face to face. Peace be to you. Our friends salute you. Greet the friends by name (3 John 1:14).
*/