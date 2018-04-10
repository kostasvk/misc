# -*- coding: utf-8 -*-
import pandas as pd #Pandas for importing
import numpy as np #Numpy for efficient calculations
import itertools as itt #Itertools to create combination pairs
from scipy import special as sp #Scipy for finding the combinations only.
import matplotlib.pyplot as plt
import sys
import math


global finaldata
class Kmeans :
    
    def __init__(self, kclust):
        #HERE CHANGE SEED IF NEEDED
        np.random.seed(10)
        self.kclust = kclust
        #Initialization of the centroids
        self.centroids = finaldata[np.random.randint(finaldata.shape[0], size=self.kclust), :-2].copy()   
        #History of clustering
        self.clustidh = np.zeros(shape=(finaldata.shape[0],1))
        self.clustid = np.zeros(shape=(finaldata.shape[0],1))
        self.tpfp=0
        self.tp=0
        self.fnarray= np.zeros(shape=(4,self.kclust))
        self.fn=0
        
    #Calculate each metric
    def metric(self,kind):        
        for i in range(finaldata.shape[0]):
            temp = []
            for j in range(self.centroids.shape[0]):
                #Manhattan distance
                if kind == 0:
                    temp.append(self.manh_dist(finaldata[i:i+1,:-2],self.centroids[j:j+1,:]))
                #Euclidean distance
                elif kind == 1:
                     temp.append(self.euclid_dist(finaldata[i:i+1,:-2],self.centroids[j:j+1,:]))
                #Cosine similarity
                elif kind == 2:
                    temp.append(self.cos_sim_dist(finaldata[i:i+1,:-2],self.centroids[j:j+1,:]))
            #Select the new cluster
            self.clustid[i] = np.argmin(temp).copy()
        #Assign new cluster
        finaldata[:,finaldata.shape[1]-1:finaldata.shape[1]] = self.clustid.copy()   
        self.clustidh=np.append(self.clustidh,self.clustid,axis=1)
        
    #Find the new centroids    
    def new_centr(self):
        for i in range(self.kclust):
            temp= np.mean(finaldata[np.where(finaldata[:,301] == i)], axis=0)
            self.centroids[i]=temp[:-2] 
    
    #Function for normalising the data
    def normalise(self):
        for i in range(finaldata.shape[1]-2 ):
            finaldata[:,i:i+1] /= math.sqrt(np.sum(finaldata[:,i:i+1]**2))
            
    def euclid_dist(self,x,y):
        return math.sqrt(np.sum((x-y)**2))
    
    def manh_dist(self,x,y):
        return np.sum(abs(x-y))
    
    def cos_sim_dist(self,x,y):
        return 1-np.sum(np.multiply(x,y))/(math.sqrt(np.sum(x**2))*math.sqrt(np.sum(y**2)))
    
    #Calculate TP, FN, FP  
    def eval_measures(self):
        #For every cluster
        for i in range(self.kclust):
            #Calculate temp, then use it for tpfp and for tp
            temp=finaldata[np.where(finaldata[:,301] == i)].copy()
            self.tpfp += sp.comb(temp.shape[0],2, exact=True)
            #For every class
            for j in range (4):
                #Keep these numbers for fn
                temp2=temp[np.where(temp[:,300]==j)].shape[0]
                #Store like this to access efficiently
                self.fnarray[j][i]=temp2
                #Calculate TP if there is at least one pair of numbers
                if temp2>1:
                    self.tp += sp.comb(temp2,2,exact=True)
        #Find the combinations and use them as indices to calculate FN
        comb = list(itt.combinations(range(self.kclust),2))
        for i in range (4):
            for j in range(len(comb)):
                x,y=comb[j]
                self.fn+=self.fnarray[i,x]*self.fnarray[i,y]
        
        
#import dataset and create a dictionary             
dataset = {}
dataset[0] = pd.read_csv('animals',delimiter= "\s+", header=None)
dataset[0].insert(dataset[0].shape[1],'class',np.zeros(dataset[0].shape[0]))
dataset[1] = pd.read_csv('countries', delimiter = "\s+", header=None)
dataset[1].insert(dataset[1].shape[1],'class',np.ones(dataset[1].shape[0]))
dataset[2] = pd.read_csv('fruits',delimiter="\s+", header=None)
dataset[2].insert(dataset[2].shape[1],'class',2*np.ones(dataset[2].shape[0]))
dataset[3] = pd.read_csv('veggies', delimiter = "\s+", header=None)
dataset[3].insert(dataset[3].shape[1],'class',3*np.ones(dataset[3].shape[0]))

#Concat files and make the "name" index
alldata = pd.concat([dataset[0], dataset[1], dataset[2], dataset[3]], join='outer', axis=0)
alldata = alldata.set_index([0])
#Insert a column that indicates the current cluster of each entry
alldata.insert(alldata.shape[1],'cluster',np.zeros(alldata.shape[0]))
finaldata = np.array(alldata).copy()


def plot_diagram(precision, recall, f_score):
    clusters = 10
    fig, ax = plt.subplots()
    index = np.arange(clusters)*2.75
    bar_width = 0.70
    opacity = 0.8
     
    plt.bar(index, precision, bar_width,
                     alpha=opacity,
                     color='b',
                     label='P')
    for i in range(len(precision)):
        plt.text(index[i]-0.2, precision[i], round(precision[i],2), color='black', fontweight='bold', fontsize=8)
        plt.text(index[i]-0.20 + bar_width, recall[i], round(recall[i],2), color='black', fontweight='bold', fontsize=8)
        plt.text(index[i]-0.2 + 2*bar_width, f_score[i], round(f_score[i],2), color='black', fontweight='bold', fontsize=8)
     
    plt.bar(index + bar_width, recall, bar_width,
                     alpha=opacity,
                     color='g',
                     label='R')   
    
    plt.bar(index + 2*bar_width, f_score, bar_width,
                     alpha=opacity,
                     color='r',
                     label='F')
     
    plt.xlabel('Cluster')
    plt.ylabel('PRF')
    plt.title('PRF per Cluster')
    plt.xticks(index + bar_width,('1','2','3','4','5','6','7','8','9','10'))
    plt.legend()
    plt.tight_layout()
    plt.show()

def main():
    #A menu for the user
    print('Please provide input tha indicates the preferable action:\n')
    print('1:Euclidean Unormalised\n')
    print('2:Euclidean Normalised\n')
    print('3:Manhattan Unormalised\n')
    print('4:Manhattan Normalised\n')
    print('5:Cosine similarity\n')
    defclass=input('Input:')
    print(defclass)
    #call functions with True or False for executing Normalisation
    if(defclass=='1'):
        euclid(False)
    elif(defclass=='2'):
        euclid(True)
    elif(defclass=='3'):
        manh(False)
    elif(defclass=='4'):
        manh(True)
    elif(defclass=='5'):
        cossim()
    else:
        print('Please provide a valid input from 1 untill 5')
        sys.exit()  
#Euclidean-If norm true normalise the data   
def euclid(norm):   
    objlist = []
    precision = []
    recall = []
    f_score = []
    
    for k in range(10):
        objlist.append(Kmeans(k+1))
        #Counter for convergence
        counter=0
        if norm:
            objlist[k].normalise()
        while counter<3:
            
            objlist[k].metric(1)
            objlist[k].new_centr()
            if np.array_equal(objlist[k].clustidh[:,-1],objlist[k].clustidh[:,-2]):
                counter += 1
            else:
                counter = 0  
        #Calling the function that calculates TP,FP,FN
        objlist[k].eval_measures()
        
        precision.append(objlist[k].tp/objlist[k].tpfp)
        recall.append(objlist[k].tp/(objlist[k].tp+objlist[k].fn))
        f_score.append((2*precision[k]*recall[k])/(precision[k]+recall[k]))
    #Plotting
    plot_diagram(precision,recall,f_score)


#Manhattan-normalised
def manh(norm):
    objlist = []
    precision = []
    recall = []
    f_score = []
    
    for k in range(10):
        objlist.append(Kmeans(k+1))
        #Counter for convergence
        counter=0
        if norm:
            objlist[k].normalise()
        while counter<3:
            
            objlist[k].metric(0)
            objlist[k].new_centr()
            if np.array_equal(objlist[k].clustidh[:,-1],objlist[k].clustidh[:,-2]):
                counter += 1
            else:
                counter = 0  
        #Calling the function that calculates TP,FP,FN
        objlist[k].eval_measures()
        
        precision.append(objlist[k].tp/objlist[k].tpfp)
        recall.append(objlist[k].tp/(objlist[k].tp+objlist[k].fn))
        f_score.append((2*precision[k]*recall[k])/(precision[k]+recall[k]))
    #Plotting
    plot_diagram(precision,recall,f_score)

#Cosine similarity-unormalised
def cossim():
    objlist = []
    precision = []
    recall = []
    f_score = []
    
    for k in range(10):
        objlist.append(Kmeans(k+1))
        #Counter for convergence
        counter=0
        objlist[k].normalise()
        while counter<3:
            
            objlist[k].metric(2)
            objlist[k].new_centr()
            if np.array_equal(objlist[k].clustidh[:,-1],objlist[k].clustidh[:,-2]):
                counter += 1
            else:
                counter = 0  
        #Calling the function that calculates TP,FP,FN
        objlist[k].eval_measures()
        
        precision.append(objlist[k].tp/objlist[k].tpfp)
        recall.append(objlist[k].tp/(objlist[k].tp+objlist[k].fn))
        f_score.append((2*precision[k]*recall[k])/(precision[k]+recall[k]))
    #Plotting
    plot_diagram(precision,recall,f_score)



if __name__ == "__main__":
    main()
