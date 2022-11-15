DROP DATABASE IF EXISTS `employeesdb`;
CREATE DATABASE IF NOT EXISTS `employeesdb`;
USE `employeesdb`;

DROP TABLE IF EXISTS `Teams`;
CREATE TABLE IF NOT EXISTS `Teams` (
  `TeamName` varchar(50) NOT NULL,
  `TeamLeader` varchar(50) NOT NULL,
  PRIMARY KEY (`TeamName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


ALTER TABLE `Teams`;
INSERT INTO `Teams` (`TeamName`, `TeamLeader`) VALUES
	('CustomerServices', 'Eline Bakken'),
	('Design', 'Mira Jacopsen'),
	('Economy', 'Karen Anderson'),
	('Finance', 'Karen Anderson'),
	('HumanResources', 'Lucy Haksen'),
	('IT', 'Hennign Harde'),
	('Logistics', 'James Moren'),
	('Management', 'Edgar Harten'),
	('Production', 'Hamsi Karaksen'),
	('ProductServices', 'Trine Mortens');


DROP TABLE IF EXISTS `Employees`;
CREATE TABLE IF NOT EXISTS `Employees` (
  `EmployeeId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Address` varchar(150) NOT NULL,
  `PhoneNumber` varchar(50) NOT NULL,
  `Birthday` date NOT NULL,
  `EmploymentStartDate` date NOT NULL,
  `JobTitle` varchar(50) NOT NULL,
  `PasswordHash` varbinary(10000) NOT NULL,
  `PasswordSalt` varbinary(10000) NOT NULL,
  `TeamName` varchar(50) NOT NULL,
  PRIMARY KEY (`EmployeeId`),
  KEY `TeamName` (`TeamName`),
  CONSTRAINT `TeamName` FOREIGN KEY (`TeamName`) REFERENCES `Teams` (`TeamName`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

INSERT INTO `Employees` (`EmployeeId`, `FirstName`, `LastName`, `Username`, `Email`, `Address`, `PhoneNumber`, `Birthday`, `EmploymentStartDate`, `JobTitle`, `PasswordHash`, `PasswordSalt`, `TeamName`) VALUES
	(1, 'Karen', 'Anderson', 'karenan', 'karen@gmail.com', 'Kristiansand', '21321321', '2022-11-09', '2022-11-02', 'Developer', _binary 0x30783237393442463042414345443934343646424531343441353442373645453241413535324241383132433435333039444343413745314335423741453745373637394641323745344337313433414141363042364230454636394532434437304231374234454238433244443436334644333031323031374439393546313646, _binary 0x307832453441383841353732333031394534373346423937424641374446433537303237364532323037373335414645463135393730453631464532384630443432383137363632344543433535393643303545343342423130304530373441464634343138423932443545414534443242433938374334373533364632343935393631304146323030363836433736464630373733433932424145434145303943424137454336363337433435373437363732443030373630414335413442463138324132453534334630344346363736434235333439423046334633423445423135334541414638333536313938434646364542303433444544343633353138, 'Finance'),
	(2, 'Morten', 'Mikkelsel', 'morten', 'morten@gmail.com', 'Grimstad', '2432432', '2017-11-09', '2021-11-09', 'Manage', _binary 0x30784542303744463641303139433341393532353045433545324230413736314141424243353130424245444436313345343543373530454244444544314433413033423733353646373345393442324441334435413438343833363043314337324539343533343445443237373841444141334130393336433546423531334437, _binary 0x307839354431334530363134344136314138333944323835413930353744443139333136373032384546373342464239344542344639374245384635333542323738453434393631434339384644414235383535343736393438394532384441443033303045383334373639303641393638324139453839364336393639393533373739464641383239463834314339353632414130324241343637313542374133444541323933414339363432313346384243343044433930334346364133343432364545453338323033313045353845303442373735433436453342314545353430443238443543373234463541333731333644353134363535434338463339, 'HumanResources'),
	(3, 'Nicky', 'Holtzen', 'nicky', 'nicky@gmail.com', 'Netherlands', '2212321323', '2022-11-13', '2022-11-13', 'Economist', _binary 0x4e04d3cdead14df307882660367287ccebd7c0c7483936e0985eaeb12059d417ff7ac5293ae21173ccdc100b20d932926487c0b82ce71b40ee3d93af9c4d9422, _binary 0x07ecb99ca38343195d4e4a1a5db4d71f34d59af0ac4af36a08ef133738ef820d8839288388508d0d9cb5bf8b4a9c0a27ef7c2d3a699c17b4070f7c236e7e9d1cec70a1243ca92a2133a510db47fb749fce9153158e6bc7861432b0ed9e63beb3b98b3b1478a4f2438a3a7ae7fd07c179ff1aea547301e686b93bfebc486110cd, 'Finance'),
	(5, 'John', 'Maker', 'john', 'john@gmail.com', 'USA', '122323213', '2022-11-13', '2022-11-13', 'Door Maker', _binary 0x0c775a4d0a636c8c4d046f1db1e5eb8a68708e4bf4d9d5a3c158f76b6ce512aefd1beeacc6ae342fdbf4f6b79fe31b293c86bb8a9f3d5522ff2aababe325ad0c, _binary 0xb002138b8c3cf3ed400aa73d11ea1d7a23b9b98790652a0f64d37257eef5bc209e499e57dd22aafffdd41badf22f7812b08c02893bf41bce5163f1321627b03f72b56dfa0fb73c23551e98052da0bff5a8e993702eb7f7a731798357f849468bb97124f2612a768f3dfb18c71a23abf29109daeea7acebf33ed3be8824044756, 'Logistics'),
	(6, 'Jenny', 'Maken', 'jenny', 'jenny@gmail.com', 'Kristiansand', '122323213', '2022-11-13', '2022-11-13', 'Door Designer', _binary 0x70faf0cdb2b2836da12a04900adfcc41d591257ba8ccbf3b564e3b8ebaa1b56dbfd362536aaf9b6a82a446f11edd530ff636079096c0fbccb183a611ea9a8d85, _binary 0x18fd52c538d323890af3b29202c47a5dcad079241840b30aa2dd3ae11c147d8be651c72792c2d32d5d44b4fff53196382a6e8694bd69bd1cb0ebf21e9a8cfec3ace80355be8aa0956046b62f7dbaaa3c5fa1e00ce99bd5fa21d64e453bbc5a560911ae2b96391e2aa9dac45feb448ed2fbb5ee507e09e0cc11d81326bbe2d168, 'Logistics'),
	(7, 'Mike', 'edson', 'mike', 'mike@gmail.com', 'Søgne', '5645654', '2022-11-13', '2022-11-13', 'IT Consulent', _binary 0x59a94226d491c884e8af972661258bdf03a9f9fc297868501630d56283cfa6f7435f8a46bef1db16b3e254a95c9a77c4e42d3b60e6b26f69aff64f6c9ce8db9e, _binary 0xa938dbb3ab9896cf86d31ca1d8831526cba6afb24d4123c014eb306363c05e0dd5d6eae7ff0ad37ad350b95ecdc03fb643929e8944614609bb5257074f273a8f74ca4e83cd86b41cf7e024f46a8d10ca5d6bf92191493b299ec371bd833423da7c9634a133ab9c9e165f3dfa0dda0cc012844d07ecae3b6350f91bb35047826a, 'HumanResources'),
	(8, 'Andrew', 'Jackson', 'andrew', 'andrew@gmail.com', 'Søgne', '5645654', '2022-11-13', '2022-11-13', 'Team Builder', _binary 0x7ff68bf2e04892eaa0d0c3ee77454332f412c6815672b27f2e5962a0fed2c3260bc34950badb772bd9fa8ad7a8ebc806b610fd610d2c35ebb8cf8aabd510be75, _binary 0x8d3e80cc6529c965da137aae0941182cbfc6260a1e2689a189601a236af95e5612b29fec55ddf18549ef3d14d2f47902a265a9ce9a4a2534d8a7ef1696ee2fb7f70186916ab4e1c2a1543eb09bf3d083dc583353020eb84ce21e609f7cbac9ab018d58b7e0239b980816c4d16842d7731c7fac0344074897aff449fd79bae9b4, 'HumanResources'),
	(9, 'Jane', 'Jackson', 'jane', 'jane@gmail.com', 'Oslo', '566545', '1983-11-13', '2022-01-13', 'Economist', _binary 0xc7270b2b128a891ce8dea7f765296762b9841fb64c62aafaa7634ba0af196a40d39b66539546c413b5c3e5469c5def0e361e17cf5d5bdc436c4a85c01d2f5e0b, _binary 0xa62e3cc7523efa282ec3f0a0a45949d6e979c422a5dd312cc8952b2983e4074f180b79ff797ed310f2454f57589151919b567b16f58f660acc2134a5f1a6a5913d7103638350acc4e92de7b6e9b670787aed57d658844c614d70676d33758471d0029b648e0404f5aa6a75d47326d6e0abf1d53f40928a3ea82d4b9957215077, 'Finance'),
	(10, 'henning', 'Harde', 'henning', 'henning@gmail.com', 'Grimstad', '43543534', '1963-11-13', '2002-01-13', 'Lead Developer', _binary 0xd6b54345dc43bcad12375748d6f6fe20a849d07148eb3531f9e6b938d80af85245ff96b156872836146ba5b2fe7905793726e30d7cae2ae2f5db4dd17ac53c6d, _binary 0xe0a0d01b14f9b047ecf4b9875385826a42287351fcda10eddfe6912e5ef97d1c1120d45d4bab7e114905f3c2a82e8ea4041c7203175bc25304eb265985489cc5715f460c1a5a96ed536dece2d659c2271f19f843a3a398f8662d5470fec09b4a7a2324ab0011cee3571c7931d1ba436a2b3829ae6754fe9862809d14e1ee362e, 'IT');

DROP TABLE IF EXISTS `Suggestions`;
CREATE TABLE IF NOT EXISTS `Suggestions` (
  `SuggestionId` int(11) NOT NULL AUTO_INCREMENT,
  `PriorityLevel` varchar(50) DEFAULT NULL,
  `SuggestionDate` date NOT NULL,
  `SuggestionResult` varchar(200) DEFAULT NULL,
  `SuggestionDescription` varchar(200) NOT NULL,
  `SuggestionStatus` varchar(50) DEFAULT NULL,
  `SuggestionGiver` varchar(50) NOT NULL,
  `TeamName` varchar(50) DEFAULT NULL,
  `SuggestionTitle` varchar(50) NOT NULL,
  `SuggestionDeadline` date DEFAULT NULL,
  PRIMARY KEY (`SuggestionId`),
  KEY `FK_TeamName` (`TeamName`),
  CONSTRAINT `FK_TeamName` FOREIGN KEY (`TeamName`) REFERENCES `Teams` (`TeamName`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

ALTER TABLE `Suggestions`;
INSERT INTO `Suggestions` (`SuggestionId`, `PriorityLevel`, `SuggestionDate`, `SuggestionResult`, `SuggestionDescription`, `SuggestionStatus`, `SuggestionGiver`, `TeamName`, `SuggestionTitle`, `SuggestionDeadline`) VALUES
	(1, 'Low', '2021-11-09', 'A new store was opend in Kristiansand', 'We need a new store house', 'Done', 'karenan', 'Logistics', 'New Store', '2022-11-09'),
	(2, 'High', '2022-10-13', 'No ready', 'We need a new designer', 'In Progress', 'Mira Jacopsen', 'HumanResources', 'New Designer', '2022-12-13'),
	(3, 'Medium', '2020-10-13', 'Not ready', 'We need a new factory to produce more doors', 'In Progress', 'Jenny Maken', 'Management', 'New Factory', '2025-12-13'),
	(4, 'Medium', '2021-10-13', 'New computer was bought', 'We need a new computer for IT department', 'Done', 'Henning Harde', 'Logistics', 'New Factory', '2025-12-13'),
	(5, 'Low', '2022-10-03', 'New security personnel', 'We need a new security personnel for night watch', 'In Progress', 'Jane jackson', 'HumanResources', 'New Factory', '2023-02-13'),
	(6, 'High', '2022-08-03', 'New door design', 'We need a new door design for Europe region', 'In Progress', 'Jane jackson', 'ProductServices', 'Karen Anderson', '2023-02-03'),
	(7, 'High', '2021-08-03', 'Department is open', 'We need a new department in Kristiansand', 'Done', 'Karen Anderson', 'ProductServices', 'New Department', '2022-02-03'),
	(8, 'High', '2021-08-03', 'Not Ready', 'We need a new accountant in Human Resources department for better financial services', 'In Progress', 'HumanResources', 'ProductServices', 'New Accountant', '2023-02-03'),
	(9, 'Medium', '2020-08-03', 'Not Ready', 'We need a new production rules for better productivity', 'In Progress', 'Mike Edson', 'Production', 'New Rules for Production', '2024-02-03'),
	(10, 'High', '2022-08-03', 'Not Ready', 'We need a new database for suggestions coming from employees', 'In Progress', 'Karen Anderson', 'IT', 'New Database', '2024-02-03');
