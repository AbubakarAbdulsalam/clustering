# clustering
The idea was to be able to group images into clusters using the KMeans Clustering Algorithm. The design choice 
is to treat each Image as an Observation that has its (width * Height) total attributes. Each atttribute is treated as having complex values
(R,G,B). Once this is done the KMeans algortihm is then applied with the only differene that it can only be applied once.

A lot of improvements still possible, numerous exceptions not properly defined or thrown, architecture could be improved and multi threading 
implemented.
